interface CGPointWrapper : Object {
    CGPoint point;
}
@property(nonatomic, assign) CGPoint point;
+(id)wrapperWithPoint:(CGPoint)p;
@end
